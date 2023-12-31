using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using ThinkLogic.Common.InputOutput;
using ThinkLogic.Common.Models;
using ThinkLogic.UI.Services;

namespace ThinkLogic.UI.Pages
{
    public partial class Index:ComponentBase
    {
        public DateTime CurrentDate { get; set; }

        public Filter PageFilter { get; set; } = new Filter();

        [Inject]
        protected IJSRuntime _js { get; set; }

        public ScheduledEvent Model { get; set; } = new ScheduledEvent();

        public ObservableCollection<ScheduledEvent> ScheduledEvents { get; set; } = new ObservableCollection<ScheduledEvent>();

        [Inject]
        ScheduledEventService ScheduledEventService { get; set; }

        public Index()
        {
            this.PageFilter.OnDateChange = () =>
            {
                Task.Run(async () =>
                {
                    await FetchSelectedMonthEvents();
                });
            };
        }

        protected async Task New()
        {
            this.Model = new ScheduledEvent();
            await Task.CompletedTask;
        }

        protected async Task Edit(ScheduledEvent scheduledEvent)
        {
            this.Model = JsonSerializer.Deserialize<ScheduledEvent>(JsonSerializer.Serialize(scheduledEvent))!;
            await Task.CompletedTask;
        }

        protected async Task Delete(int id)
        {
            await ScheduledEventService.DeleteAsync(id);
            await FetchSelectedMonthEvents();
        }
        protected async Task Save()
        {
            var response = new TLResponse<int>();

            if (this.Model.Id > 0)
            {
                response = await ScheduledEventService.UpdateAsync(this.Model);
            }
            else
            {
                response = await ScheduledEventService.InsertAsync(this.Model);
            }

            if (response.HasStopEventMessages)
            {
                StringBuilder sb = new StringBuilder();
                response.Messages.ForEach(x =>
                {
                    sb.AppendLine(x.Text);
                });

                await _js.InvokeVoidAsync("alert", sb.ToString());
            }

            await FetchSelectedMonthEvents();
        }
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await FetchSelectedMonthEvents();
        }

        protected async Task FetchSelectedMonthEvents()
        {
            TLRequest<ScheduledEvent> request = new TLRequest<ScheduledEvent>();
            request.FilterObject = new ScheduledEvent();

            request.FilterObject.StartDate = new DateTime(this.PageFilter.Date.Year, this.PageFilter.Date.Month, this.PageFilter.Date.Day, 0, 0, 0);
            request.FilterObject.EndDate = new DateTime(this.PageFilter.Date.Year, this.PageFilter.Date.Month, this.PageFilter.Date.Day, 23, 59, 59);

            var response = await ScheduledEventService.GetByRequestAsync(request);

            this.ScheduledEvents = new ObservableCollection<ScheduledEvent>(response?.Data!);

            await Task.CompletedTask;
        }

        public class Filter
        {
            private DateTime _date = DateTime.Now;
            public DateTime Date
            {
                get
                {
                    return _date;
                }
                set
                {
                    _date = value;

                    if (OnDateChange != null)
                    {
                        OnDateChange();
                    }
                }
            }
            public Action? OnDateChange { get; set; }
        }
    }


}