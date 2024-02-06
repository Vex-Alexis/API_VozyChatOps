using System.Reflection.Metadata;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Newtonsoft.Json;
using System.Text;
using API_VozyChatOps.Models;
using QuestPDF.Previewer;
using System.Security.Cryptography;

namespace API_VozyChatOps.Services
{
    public class PDFGenerationService
    {
        private readonly ScheduleService _scheduleService;

        public PDFGenerationService(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async Task<String> GeneratePdfAsync(string numIdentificacion)
        {
            var schedules = await _scheduleService.GetSchedulesByNumIdentificacionAsync(numIdentificacion);


            using (var memoryStream = new MemoryStream())
            {
                var document = QuestPDF.Fluent.Document.Create(document =>
                {

                    document.Page(page =>
                    {
                        // ## CONFIGURATION ##

                        page.Size(PageSizes.A4.Landscape());


                        // ## HEADER ##

                        page.Header()
                        .ShowOnce()
                        .Height(152)
                        .Background("#1f2936")
                        .Row(row => {
                            row.ConstantItem(255)
                                .Image("assets/log1.png");

                            row.RelativeItem()
                                .PaddingVertical(16)
                                .PaddingHorizontal(2)
                                .Column(col =>
                                {
                                    col.Item().Height(35)//.Background("#f44")
                                    .AlignCenter()
                                    //.Text("Horario de clases")
                                    .Text("HORARIO DE CLASES")
                                    .Bold()
                                    .FontSize(20)
                                    .FontColor("#91dc00");

                                    col.Item().Height(34)//.Background("#f44")
                                                         //.Text("TÉCNICA PROFESIONAL")
                                    .AlignCenter()
                                    .Text($"{schedules[0].NOM_UNIDAD}")
                                    .LineHeight(1f)
                                    .FontSize(14)
                                    .FontColor("#fff");


                                    col.Item().Height(25)//.Background("#f44")
                                    .Row(row => {
                                        row.RelativeItem(3)
                                        .Text(txt =>
                                        {
                                            txt.Span("Cód.Programa: ").SemiBold().FontSize(14).FontColor("#91dc00");
                                            txt.Span($"1TC57").FontSize(14).FontColor("#fff");

                                        });

                                        row.RelativeItem(7)
                                        .Text(txt =>
                                        {
                                            txt.Span("Estudiante: ").SemiBold().FontSize(14).FontColor("#91dc00");
                                            txt.Span($"{schedules[0].NOM_LARGO}").FontSize(14).FontColor("#fff");
                                        });

                                    });




                                    col.Item().Height(25)//.Background("#f44");
                                    .Row(row => {
                                        row.RelativeItem(3)
                                        .Text(txt =>
                                        {
                                            txt.Span("Cód.Pensum: ").SemiBold().FontSize(14).FontColor("#91dc00");
                                            txt.Span($"5031D").FontSize(14).FontColor("#fff");

                                        });

                                        row.RelativeItem(7)
                                        .Text(txt =>
                                        {
                                            txt.Span("Documento: ").SemiBold().FontSize(14).FontColor("#91dc00");
                                            txt.Span($"{schedules[0].NUM_IDENTIFICACION}").FontSize(14).FontColor("#fff");
                                        });
                                    });
                                });
                        });


                        // ## CONTENT ##

                        page.Content().Background("#91dc00")
                        .PaddingVertical(16)
                        .PaddingHorizontal(24)
                        .Column(col =>
                        {
                            col.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    //columns.RelativeColumn();
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();

                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    //header.Cell().Background("#1f2936").Padding(5).Text("Código Materia").FontColor("#fff").FontSize(14);
                                    header.Cell().Background("#1f2936").Padding(5).Text("Nombre Materia").FontColor("#fff").FontSize(14);
                                    header.Cell().Background("#1f2936").Padding(5).Text("Día").FontColor("#fff").FontSize(14);
                                    header.Cell().Background("#1f2936").Padding(5).Text("Hora inicial").FontColor("#fff").FontSize(14);
                                    header.Cell().Background("#1f2936").Padding(5).Text("Hora final").FontColor("#fff").FontSize(14);
                                    header.Cell().Background("#1f2936").Padding(5).Text("Aula").FontColor("#fff").FontSize(14);

                                    header.Cell().Background("#1f2936").Padding(5).Text("Docente").FontColor("#fff").FontSize(14);
                                    header.Cell().Background("#1f2936").Padding(5).Text("Fecha inicio").FontColor("#fff").FontSize(14);
                                    header.Cell().Background("#1f2936").Padding(5).Text("Fecha final").FontColor("#fff").FontSize(14);

                                });

                                //List<ScheduleModel> scheduleList = JsonConvert.DeserializeObject<List<ScheduleModel>>(schedules); ;


                                foreach (var clase in schedules)
                                {
                                    string COD_MATERIA = "";
                                    string NOM_MATERIA = "";
                                    string DIA = "";
                                    string HORA_INICIAL = "";
                                    string HORA_FINAL = "";
                                    string NOM_AULA = "";
                                    string NOM_DOCENTE = "";
                                    string FEC_INI_PROGRAMACION = "";
                                    string FEC_FIN_PROGRAMACION = "";


                                    //table.Cell().BorderBottom(0.5f).BorderColor("#fff")
                                    //.Padding(5)
                                    //.AlignMiddle()
                                    //.Padding(2).Text($"{clase.COD_MATERIA}").FontSize(12);                                  


                                    table.Cell().BorderBottom(0.5f).BorderColor("#fff")
                                    .Padding(5)
                                    .AlignMiddle()
                                    .Padding(2).Text($"{clase.NOM_MATERIA}").FontSize(12);

                                    table.Cell().BorderBottom(0.5f).BorderColor("#fff")
                                    .Padding(5)
                                    .AlignMiddle()
                                    .Padding(2).Text($"{clase.DIA}").FontSize(12);

                                    table.Cell().BorderBottom(0.5f).BorderColor("#fff")
                                    .Padding(5)
                                    .AlignMiddle()
                                    .Padding(2).Text($"{clase.HORA_INICIAL}").FontSize(12);

                                    table.Cell().BorderBottom(0.5f).BorderColor("#fff")
                                    .Padding(5)
                                    .AlignMiddle()
                                    .Padding(2).Text($"{clase.HORA_FINAL}").FontSize(12);

                                    table.Cell().BorderBottom(0.5f).BorderColor("#fff")
                                    .Padding(5)
                                    .AlignMiddle()
                                    .Padding(2).Text($"{clase.NOM_AULA}").FontSize(12);


                                    table.Cell().BorderBottom(0.5f).BorderColor("#fff")
                                    .Padding(5)
                                    .AlignMiddle()
                                    .Padding(2).Text($"{clase.NOM_DOCENTE}").FontSize(12);

                                    table.Cell().BorderBottom(0.5f).BorderColor("#fff")
                                    .Padding(5)
                                    .AlignMiddle()
                                    .Padding(2).Text($"{clase.FEC_INI_PROGRAMACION?.ToString("yyyy-MM-dd")}").FontSize(12);

                                    table.Cell().BorderBottom(0.5f).BorderColor("#fff")
                                    .Padding(5)
                                    .AlignMiddle()
                                    .Padding(2).Text($"{clase.FEC_FIN_PROGRAMACION?.ToString("yyyy-MM-dd")}").FontSize(12);
                                }
                            });
                        });


                        // ## FOOTER ##
                        page.Footer().Height(18)
                        .AlignCenter()
                        .Text("© 2024 CUN: Corporación Unificada Nacional de Educación Superior");
                    });
                });
                    
                //document.ShowInPreviewer();
                document.GeneratePdf(memoryStream);

                // Convertir el contenido del MemoryStream en un array de bytes
                var pdfBytes = memoryStream.ToArray();

                // Convertir el array de bytes a una cadena BASE64
                var pdfBase64 = Convert.ToBase64String(pdfBytes);

                return pdfBase64;
            }
        }
    }
}
