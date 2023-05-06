using CsvHelper;
using CsvHelper.Configuration;
using server.Models;
using server.Services;
using System.Globalization;
using System.Text;

namespace server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var csvData = LoadCsvData();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IStaticDataService>(new StaticDataService(csvData));
            builder.Services.AddTransient<IGwpService, GwpService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public static List<GwpCsv> LoadCsvData()
        {
            List<GwpCsv> dataList = new List<GwpCsv>();
            var fileName = @"gwpByCountry.csv";
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };

            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var textReader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(textReader, configuration))
                {
                    var data = csv.GetRecords<GwpCsv>();

                    foreach (var item in data)
                    {
                        dataList.Add(item);
                    }
                }
            }
            return dataList;
        }
    }
}