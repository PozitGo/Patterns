using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Machine
{

    public class Machine
    {
        public enum State
        {
            OffHook, Connecting, Connected, OnHold, OnHook
        }

        public enum Trigger
        {
            CallDialed, HungUp, CallConnected, PlacedOnHold, TakenOffHold, LeftMessage
        }

        public static Dictionary<State, List<(Trigger, State)>> rules = new Dictionary<State, List<(Trigger, State)>>
        {
            [State.OffHook] = new List<(Trigger, State)>
            {
                (Trigger.CallDialed, State.Connecting)
            },
            [State.Connecting] = new List<(Trigger, State)>
            {
              (Trigger.HungUp, State.OnHook),
              (Trigger.CallConnected, State.Connected)
            },
            [State.Connected] = new List<(Trigger, State)>
            {
              (Trigger.LeftMessage, State.OnHook),
              (Trigger.HungUp, State.OnHook),
              (Trigger.PlacedOnHold, State.OnHold)
            },
            [State.OnHold] = new List<(Trigger, State)>
            {
              (Trigger.TakenOffHold, State.Connected),
              (Trigger.HungUp, State.OnHook)
            }
        };
    }
}
