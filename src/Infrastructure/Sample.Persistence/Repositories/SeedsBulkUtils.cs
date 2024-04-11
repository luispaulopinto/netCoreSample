using Sample.Domain.Entities;

namespace Sample.Persistence.Repositories
{
    public class SeedsBulkUtils
    {
        public List<Client> create5ChildrenClients(
            int number,
            string currentPath,
            string currentType,
            ref int clientId,
            int parentId
        )
        {
            if (string.IsNullOrEmpty(currentPath))
                return [];

            string nextPath;
            string nextType = currentType;

            switch (currentPath)
            {
                case "Grupo":
                    nextPath = "Grupo/Rede";
                    nextType = "Rede";
                    break;
                case "Grupo/Rede":
                    nextPath = "Grupo/Rede/Parceiro";
                    nextType = "Parceiro";
                    break;
                // case "Grupo/Parceiro":
                //     nextPath = "Grupo/Parceiro";
                //     nextType = "Parceiro";
                //     break;
                // case "Grupo/Hotel":
                //     nextPath = "Grupo/Hotel";
                //     nextType = "Hotel";
                //     break;
                case "Grupo/Rede/Parceiro":
                    nextPath = "Grupo/Rede/Parceiro/Hotel";
                    nextType = "Hotel";
                    break;
                case "Grupo/Rede/Parceiro/Hotel":
                    nextPath = "";
                    nextType = "Hotel";
                    break;
                case "Grupo/Parceiro":
                    nextPath = "Grupo/Parceiro/Hotel";
                    nextType = "Hotel";
                    break;
                case "Grupo/Parceiro/Hotel":
                    nextPath = "";
                    nextType = "Hotel";
                    break;
                case "Grupo/Hotel":
                    nextPath = "";
                    nextType = "Hotel";
                    break;
                case "Rede":
                    nextPath = "Rede/Parceiro";
                    nextType = "Parceiro";
                    break;
                case "Rede/Parceiro":
                    nextPath = "Rede/Parceiro/Hotel";
                    nextType = "Hotel";
                    break;
                case "Rede/Parceiro/Hotel":
                    nextPath = "";
                    nextType = "Hotel";
                    break;
                case "Rede/Hotel":
                    nextPath = "";
                    nextType = "Hotel";
                    break;
                case "Parceiro":
                    nextPath = "Parceiro/Hotel";
                    nextType = "Hotel";
                    break;
                case "Parceiro/Hotel":
                    nextPath = "";
                    nextType = "Hotel";
                    break;
                default:
                    nextPath = "";
                    nextType = "Hotel";
                    break;
            }

            List<Client> clients = new List<Client>();

            for (int i = 0; i < 3; i++)
            {
                clientId++;
                clients.Add(
                    new Client
                    {
                        Id = clientId,
                        ParentClientId = parentId,
                        Name = $"{currentPath} {number}",
                        CurrencyType = "BR",
                        IsStateRegistrationFree = false,
                        Language = "pt-BR",
                        LogoURL = "logo_URL",
                        Origin = "Origem",
                        RegisteredNumber = "000000",
                        StateRegistration = "000000",
                        TimeZone = "Fuso",
                        TradeName = $"Fantasia {number}",
                        Type = currentType,
                        Address = new Address()
                        {
                            Street = $"Street {number}",
                            StreetNumber = "100",
                            City = "City",
                            State = "State",
                            Country = "Country",
                            District = "District",
                            PostalCode = "00000-000",
                            Complement = "Complement"
                        },
                        ChildrenChain = create5ChildrenClients(
                            number,
                            nextPath,
                            nextType,
                            ref clientId,
                            parentId
                        )
                    }
                );
            }
            return clients;
        }
    }
}
