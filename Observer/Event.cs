namespace Observer
{
    public class FallsIllEventArgs : EventArgs
    {
        public required string Address;
    }
    public class Person
    {

        #nullable disable
        public event EventHandler<FallsIllEventArgs> FallsIll;
        public void CatchACold()
        {
            FallsIll?.Invoke(this, 
                new FallsIllEventArgs
                {
                    Address = "123 London Road"
                });
        }
    }
}
