using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBank.Utilities
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
        public const string Role_User_Company = "Company";
        public const string Role_User_Individual = "Individual";


        public const string StatusPending = "Pending"; // Initial State when order is created.
        public const string StatusApproved = "Approved"; //When customer can approved a payment , change the status to approved
        public const string StatusInProcess = "Processing"; //it is updated by admin,when they are processing the order.
        public const string StatusShipped = "Shipped"; //when processing is done , order will be status.
        public const string StatusCancelled = "Cancelled"; //when customer can cancel to buy the item.
        public const string StatusRefunded = "Refunded"; //when customer can cancel to buy an item refund is use.


        public const string PaymentStatusPending = "Pending"; //initial state for payment pending.
        public const string PaymentStatusApproved = "Approved"; //when pay the money by customer.
        public const string PaymenStatusDelayedPayment = "ApprovedForDelayedPayment"; //when it's a company account,then this status is showed for approved for payment delayed.
        public const string PaymentRejected = "Rejected"; //when payment is rejected.

        public const string SessionCart = "SessionShoppingCart"; 

    }
}
