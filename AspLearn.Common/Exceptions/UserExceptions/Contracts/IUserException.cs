namespace AspLearn.Common.Exceptions.UserExceptions.Contracts {
    public interface IUserException {
        string GetUserMessageException { get; }

        void SetUserMessage(string message);
    }
}
