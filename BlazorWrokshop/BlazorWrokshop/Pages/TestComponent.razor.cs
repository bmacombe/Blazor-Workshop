using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWrokshop.Pages
{
    public class TestComponentCode : ComponentBase
    {
        [Parameter]
        public Customer SelectedCustomer { get; set; }

        [Parameter]
        public EventCallback<int> CustomerResetEvent { get; set; }

        public async Task ResetButtonClicked()
        {
            await CustomerResetEvent.InvokeAsync(SelectedCustomer.CustomerId);
        }

        [Parameter]
        public List<Customer> Customers { get; set; } = new List<Customer>();

        [Parameter]
        public EventCallback<Customer> CustomerSelectEvent { get; set; }

        public async Task CustomerSelected(ChangeEventArgs args)
        {
            SelectedCustomer = (from x in Customers
                                where x.CustomerId.ToString()
                                      == args.Value.ToString()
                                select x).First();
            await CustomerSelectEvent.InvokeAsync(SelectedCustomer);
        }

        public string NewCustomerName = "";


        [Parameter]
        public EventCallback<string> AddCustomerEvent { get; set; }


        public async Task CustomerAdding()
        {
            await AddCustomerEvent.InvokeAsync(NewCustomerName);
        }
    }
}
