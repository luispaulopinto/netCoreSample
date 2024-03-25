using System;
using System.CodeDom.Compiler;
using Sample.Application.Features.Clients.Commands.CreateClient;
using Sample.Domain.Entities;

namespace Sample.Application.UnitTests.Builders
{
    public class ClientCommandBuilder //: Builder<CreateClientCommand>
    {
        private CreateClientCommand Object = new CreateClientCommand();
        private String _name = string.Empty;
        private String _type = string.Empty;
        private String _tradeName = string.Empty;
        private String _registeredNumber = string.Empty;
        private String _stateRegistration = string.Empty;
        private Boolean _isStateRegistrationFree = false;
        private String _logoURL = string.Empty;
        private String _language = string.Empty;
        private String _currencyType = string.Empty;
        private String _timeZone = string.Empty;
        private String _origin = string.Empty;

        public CreateClientCommand Build()
        {
            if (Object is not null)
            {
                Object = new CreateClientCommand()
                {
                    Name = _name,
                    Type = _type,
                    TradeName = _tradeName,
                    RegisteredNumber = _registeredNumber,
                    StateRegistration = _stateRegistration,
                    IsStateRegistrationFree = _isStateRegistrationFree,
                    LogoURL = _logoURL,
                    Language = _language,
                    CurrencyType = _currencyType,
                    TimeZone = _timeZone,
                    Origin = _origin
                };
            }

            // PostBuild(Object.Value);

            return Object;
        }

        public static ClientCommandBuilder Default()
        {
            return new ClientCommandBuilder();
        }

        public static ClientCommandBuilder Simple()
        {
            return Default()
                .WithName("New Client")
                .WithType("Grupo")
                .WithTradeName("Trade Name")
                .WithRegisteredNumber("000-00")
                .WithStateRegistration("000")
                .WithIsStateRegistrationFree(false)
                .WithLogoURL("url")
                .WithLanguage("language")
                .WithCurrencyType("currency")
                .WithTimeZone("timezone")
                .WithOrigin("origin");
        }

        public ClientCommandBuilder WithName(string value)
        {
            _name = value;
            return this;
        }

        public ClientCommandBuilder WithoutName()
        {
            _name = string.Empty;
            return this;
        }

        public ClientCommandBuilder WithType(string value)
        {
            _type = value;
            return this;
        }

        public ClientCommandBuilder WithoutType()
        {
            _type = string.Empty;
            return this;
        }

        public ClientCommandBuilder WithTradeName(string value)
        {
            _tradeName = value;
            return this;
        }

        public ClientCommandBuilder WithRegisteredNumber(string value)
        {
            _registeredNumber = value;
            return this;
        }

        public ClientCommandBuilder WithStateRegistration(string value)
        {
            _stateRegistration = value;
            return this;
        }

        public ClientCommandBuilder WithIsStateRegistrationFree(Boolean value)
        {
            _isStateRegistrationFree = value;
            return this;
        }

        public ClientCommandBuilder WithLogoURL(string value)
        {
            _logoURL = value;
            return this;
        }

        public ClientCommandBuilder WithLanguage(string value)
        {
            _language = value;
            return this;
        }

        public ClientCommandBuilder WithCurrencyType(string value)
        {
            _currencyType = value;
            return this;
        }

        public ClientCommandBuilder WithTimeZone(string value)
        {
            _timeZone = value;
            return this;
        }

        public ClientCommandBuilder WithOrigin(string value)
        {
            _origin = value;
            return this;
        }

        // private Lazy<System.String> _name = new Lazy<System.String>(default(System.String));

        // public override CreateClientCommand Build()
        // {
        //     if (Object?.IsValueCreated != true)
        //     {
        //         Object = new Lazy<CreateClientCommand>(
        //             new CreateClientCommand { Name = _name.Value }
        //         );
        //     }

        //     PostBuild(Object.Value);

        //     return Object.Value;
        // }

        // public static ClientCommandBuilder Simple()
        // {
        //     return Default();
        // }

        // public static ClientCommandBuilder Default()
        // {
        //     return new ClientCommandBuilder();
        // }

        // public ClientCommandBuilder WithName(System.String value)
        // {
        //     return WithName(() => value);
        // }

        // [GeneratedCode("ModelBuilders", "1.0")]
        // public ClientCommandBuilder WithName(Func<System.String> func)
        // {
        //     _name = new Lazy<System.String>(func);
        //     return this;
        // }

        // [GeneratedCode("ModelBuilders", "1.0")]
    }
}
