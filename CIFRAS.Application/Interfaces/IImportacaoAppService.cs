using System.Web;

namespace CIFRAS.Application.Interfaces
{
    public interface IImportacaoAppService
    {
        string ImportarArquivo(HttpPostedFileBase arquivo, int tipoClienteId);
    }
}