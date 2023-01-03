using System.Web;
using CIFRAS.Application.Interfaces;
using CIFRAS.Domain.Interfaces.Services;

namespace CIFRAS.Application.AppServices
{
    public class ImportacaoAppService : IImportacaoAppService
    {
        private readonly IImportacaoService _importacaoService;

        public ImportacaoAppService(IImportacaoService importacaoService)
        {
            _importacaoService = importacaoService;
        }

        public string ImportarArquivo(HttpPostedFileBase arquivo, int tipoClienteId)
        {
            return _importacaoService.ImportarArquivo(arquivo, tipoClienteId);
        }
    }
}