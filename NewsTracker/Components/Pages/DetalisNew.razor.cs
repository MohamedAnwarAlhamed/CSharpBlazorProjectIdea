using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using NewsTracker.Model;
using NewsTracker.Services;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NewsTracker.Components.Pages
{
    public partial class  DetalisNew
    {

        [Parameter]
        public int newsId { get; set; }

        [Inject] private NewsService NewsService { get; set; }

        private NewsItem newsItem = new NewsItem();

        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            newsItem = await NewsService.GetNewsByIdAsync2(newsId); // جلب تفاصيل الخبر
        }
    }
}




