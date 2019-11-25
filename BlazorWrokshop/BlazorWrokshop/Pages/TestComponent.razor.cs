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
        public EventCallback<Customer> AddCustomerEvent { get; set; }
        bool Adding = false;

        public void CustomerAdding()
        {
            SelectedCustomer = new Customer();
            Adding = true;
        }

        [Parameter]
        public EventCallback<Customer> UpdateCustomerEvent { get; set; }
        public async Task UpdateButtonClicked()
        {
            if (Adding)
            {
                Adding = false;
                await AddCustomerEvent.InvokeAsync(SelectedCustomer);
            }
            else
            {
                await UpdateCustomerEvent.InvokeAsync(SelectedCustomer);
            }
        }

        [Parameter]
        public EventCallback<int> DeleteCustomerEvent { get; set; }
        public async Task DeleteButtonClicked()
        {
            await DeleteCustomerEvent.InvokeAsync(SelectedCustomer.CustomerId);
        }
    }
}
