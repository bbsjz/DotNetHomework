using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
namespace OrderApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private OrderContext orderDb;

    //构造函数把orderContext 作为参数，Asp.net core 框架可以自动注入orderContext对象
    public OrderController(OrderContext context)
    {
        this.orderDb = context;
    }


    // POST: api/todo
    [HttpPost]
    public ActionResult<Order> PostOrder(Order order)
    {
        try
        {
            orderDb.orderItems.Add(order);
            orderDb.SaveChanges();
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException.Message);
        }
        return order;
    }
}
