using Applications.Metrics.Queries;
using Domain;
using Domain.Models;
using MediatR;

namespace Applications.Metrics.Handlers
{
    public class MetricsSalesQueryHandler : IRequestHandler<MetricsSalesQuery, Response>
    {
        private readonly IResponse _response;


        public MetricsSalesQueryHandler(IResponse response)
        { 
            _response = response;
        }

        public async Task<Response> Handle(MetricsSalesQuery request, CancellationToken cancellationToken)
        {
            var metrics = new List<MetricsSales>();

            DateTime dataInicial = new DateTime(2023, 1, 1);
            DateTime dataFinal = new DateTime(2023, 12, 31);
            Random random = new Random();



            for (int i = 0; i < 60; i++)
            {
                var metric = new MetricsSales();

                metric.Date = GerarDataAleatoria(dataInicial, dataFinal, random);
                metric.Value = GerarValorDoubleAleatorio(random, 0.0, 1000.0) ;

                metrics.Add(metric);
            }

            return await _response.CreateSuccessResponseAsync(metrics, string.Empty);


        }

        static DateTime GerarDataAleatoria(DateTime dataInicial, DateTime dataFinal, Random random)
        {
            int range = (dataFinal - dataInicial).Days;
            int diasAleatorios = random.Next(range);

            return dataInicial.AddDays(diasAleatorios);
        }

        static double GerarValorDoubleAleatorio(Random random, double valorMinimo, double valorMaximo)
        {
            return valorMinimo + (valorMaximo - valorMinimo) * random.NextDouble();
        }


    }
}
