namespace CarRentalSystem.Common.Services
{
    using CarRentalSystem.Common.Services.Contracts;

    public class CurrentTokenService : ICurrentTokenService
    {
        private string currentToken;

        public string Get() => this.currentToken;

        public void Set(string token) => this.currentToken = token;
    }
}
