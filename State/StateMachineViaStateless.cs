using Stateless;

namespace State.Stateless
{
    //Nuget Stateless
    public static class StateStateless
    {
        public enum Trigger
        {
            On, Off
        }

        public static void Execute()
        {
            //Тип состояния, начальное состояние, тип триггеров которые его меняют
            var light = new StateMachine<bool, Trigger>(false);

            //Указываем как триггеры должны менять состояние, OnEntry вызывает какой-то код в момент входа в это состояние
            light.Configure(false).Permit(Trigger.On, true).OnEntry(transition =>
            {
                if(transition.IsReentry)
                {
                    Console.WriteLine("Light is already off");
                }
                else
                {
                    Console.WriteLine("Switching light off");
                }
            }).PermitReentry(Trigger.Off);
            //Выводим сообщение в момент включения и игнорируем следующие попытки включить свет если он и так включен
            light.Configure(true).Permit(Trigger.Off, false).OnEntry(transition => Console.WriteLine("Turning light on")).Ignore(Trigger.On);

            //Работаем с переменной которая работает с состоянием, меняя его через триггеры
            light.Fire(Trigger.On);
            light.Fire(Trigger.Off);
            light.Fire(Trigger.Off);
        }
    }
}
