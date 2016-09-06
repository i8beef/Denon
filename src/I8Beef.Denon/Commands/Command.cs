namespace I8Beef.Denon.Commands
{
    public abstract class Command
    {
        public abstract string Code { get; }
        public string Value { get; set; }
        public abstract string GetHttpCommand();
        public abstract string GetTelnetCommand();
    }
}
