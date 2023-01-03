using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace CIFRAS.Application.ViewModel
{
    public class EnderecoVm
    {
        #region Atributos
        public int EnderecoId { get; set; }

        [Display(Name = "Endereço")]
        public string NomeEndereco { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public Estado? Estado { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }
        #endregion

        #region Listas
        [ScriptIgnore]
        public ICollection<ClienteVm> ListaCliente { get; set; }
        #endregion

        #region Não mapeados
        public string EstadoView => Estado.ToString();
        #endregion
    }
}