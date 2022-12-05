using Microsoft.AspNetCore.Mvc;
using Subscription.DBContext;
using Model=Subscription.Model;
using Subscription.Rpository;

namespace Subscription.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private SubscriptionContext _context;

        private readonly ILogger<SubscriptionController> _logger;

        public SubscriptionController(ILogger<SubscriptionController> logger)
        {
            _logger = logger;
            _context = new SubscriptionContext();

        }

        [HttpGet]
        public IEnumerable<Model.Subscription> Get()
        {
            return _context.Subscriptions.ToList();
        }

        [HttpGet("{subscriberName}")]
        public IEnumerable<Model.Subscription> Get(string subscriberName)
        {
            return _context.Subscriptions.Where(x => x.SubscriberName == subscriberName).ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Model.SubscriptionApiData apiData)
        {
            var books=new Books();
            if (books.GetAvailableCopies(apiData.BookId) > 0)
            {
                _context.Add<Model.Subscription>(new Model.Subscription() { BookId = apiData.BookId, SubscriberName = apiData.SubscriberName, DateSubscribed = apiData.DateSubscribed });
                _context.SaveChanges();
                return StatusCode(201);
            }
            else
            {
                return StatusCode(422);
            }
            
        }
    }
}