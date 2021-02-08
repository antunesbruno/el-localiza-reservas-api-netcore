using el.localiza.reservas.api.netcore.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace el.localiza.reservas.api.netcore.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string logradouro, int numero, string complemento, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;

            //valida o Numero
            AddNotifications(new Contract()
              .Requires()
              .IsDigit(Numero.ToString(), nameof(Numero), "Número da residência não pode conter letras !")
              .IsNotNullOrWhiteSpace(Numero.ToString(), nameof(Numero), "Número da residência não pode ser nulo ou branco")
              .IsGreaterOrEqualsThan(Numero, 0, nameof(Numero), "Número da residênca deve ser maior que zero !"));

            //valida o Estado
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Estado, nameof(Estado), "Estado não pode ser nulo ou branco")
                .HasLen(Estado, 2, nameof(Estado), "A sigla de Estado deve conter 2 dígitos !"));

            //valida o CEP
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Cep, nameof(Cep), "CEP não pode ser nulo ou branco")
                .HasLen(Cep, 8, nameof(Cep), "CEP deve conter 8 dígitos !")
                .IsDigit(Cep, nameof(Cep), "CEP deve conter apenas números"));


        }

        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
    }

}
