using System.Collections.Generic;

namespace MicroRabbitMQ.Banking.Application.Account.Queries.GetAll {
    public class AllAccountsView {
        public int Quantity { get; set; }
        public IList<AllAccountsViewItem> Items { get; set; }

        public class AllAccountsViewItem {
            public int Id { get; set; }
            public string AccountType { get; set; }
            public decimal Balance { get; set; }

        }
    }
}
