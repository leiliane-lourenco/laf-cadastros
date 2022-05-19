using LAF.Cadastros.Application;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using LAF.Cadastros.Repository;
using LAF.Cadastros.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace LAF.Cadastros.IoC.Dependency
{
    public static class InjecaoDependencia
    {
        public static void Registrar(IServiceCollection services)
        {
            Container.RegistrarMapeamentosDapper();

            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<IFornecedorApplication, FornecedorApplication>();
            services.AddScoped<IProdutoApplication, ProdutoApplication>();
            services.AddScoped<IEnderecoApplication, EnderecoApplication>();


        }
    }
}
