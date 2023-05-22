using Hangfire;

namespace UdemyClone.Extensions
{
    public static class HangfireJobs
    {
        public static void RecurringJobs()
        {
            //RecurringJob.AddOrUpdate<IAgendaMarkerService>("2",x => x.Create(new AgendaMarkerCreateDto { Color = "Kuqe" }), Cron.Minutely); 

            //RecurringJob.AddOrUpdate<IArticleService>("2", x => x.Create(new ArticleCreateDto { AdditionalText = "Test for action methods" }), Cron.Minutely);
        }
        //Hangfire.RecurringJob.AddOrUpdate<IAgendaMarkerService>(x => x.Create(new AgendaMarkerCreateDto { Color="Kuqe"}), Cron.Minutely);
        //RecurringJob.AddOrUpdate<IAgendaMarkerService>(x => x.Create(new AgendaMarkerCreateDto { Color="Kuqe"}), Cron.Minutely);

        //RecurringJob.AddOrUpdate("2", () => _agendaMarkerService.Create(new AgendaMarkerCreateDto { Color = "red", Day = "mondayTestttttt" }), Cron.Minutely);
        //        _logger.LogInformation("Request for GetAllForPagination Recived.");
        //public void RecurringJob(this IServiceCollection services)
        //{



        //    //services.AddTransient<IAgendaMarkerService, AgendaMarkerService>();


        //}
        //RecurringJob.AddOrUpdate<IAgendaMarkerService>(x => x.Create(new AgendaMarkerCreateDto { Color="Kuqe"}), Cron.Minutely);

    }

}
