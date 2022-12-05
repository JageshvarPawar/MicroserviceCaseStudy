namespace Subscription.Model
{
    public class Subscription
    {
        public int Id { get; set; }
        public string SubscriberName { get; set; }
        public DateTime DateSubscribed { get; set; }
        public DateTime DateReturned { get; set; }
        public string BookId { get; set; }

    }

    public class SubscriptionApiData
    {
        public string SubscriberName { get; set; }
        public string BookId { get; set; }
        public DateTime DateSubscribed { get; set; }
    }

}
