using System.Web;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface IImportacaoService
    {
        string ImportarArquivo(HttpPostedFileBase arquivo, int tipoClienteId);
    }
}