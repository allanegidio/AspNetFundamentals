using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;

namespace KatanaConsoleApp
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    /* Para rodar no Console
     * -> Adicionar bin\Debug nas propriedades/Build do projeto
     * -> Criar o metodo estatico Main com o Start do servidor.
     * -> Mudar de Class Library para Console Application
     * -> Ter um arquivo com o nome de App.Config
    */

    /* Para rodar no IIS
     * -> Remover a pasta "Debug" e deixar apenas a "bin" nas propriedades/Build do projeto
     * -> Remover o método estatico Main com o Start do servidor.
     * -> Mudar de Console Application para Class Library 
     * -> Ter um arquivo com o nome de WebConfig
    */

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var uri = "http://localhost:8080";

    //        using (WebApp.Start<StartUp>(uri))
    //        {
    //            Console.WriteLine("Started!!!");
    //            Console.ReadKey();
    //            Console.WriteLine("Stopping!!!");
    //        }
    //    }
    //}

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (environment, next) =>
            {
                Console.WriteLine("Requesting: " + environment.Request.Path);

                await next();

                Console.WriteLine("Response: " + environment.Response.StatusCode);
            });

            ConfigureWebApi(app);

            app.UseHelloWorld();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute("DefaultApi",
                                       "api/{controller}/{id}",
                                       new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }


    //Crio uma extensão para IAppBuilder para encapsular as classes dos componentes.
    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    //Crio um component que servira como um interceptador(Middleware) da request. 
    public class HelloWorldComponent
    {
        AppFunc _next;

        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> enviroment)
        {
            var response = enviroment["owin.ResponseBody"] as Stream;
            using(var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!!!");
            }
        }
    }
}
