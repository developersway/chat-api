using System.Threading.Tasks;
using dot_net.userMessages;
using Microsoft.AspNetCore.Mvc;
using PusherServer;

namespace dotnet_chat.Controllers
{
    [Route("api")]
    [ApiController]
    public class ChatController : Controller
    {
        [HttpGet("serverData")]
        public IActionResult Get()
        {
            return Json(MessageDatabase.msgList.ToList());
        }

        
        [HttpPost("messages")]
        public async Task<ActionResult> Message(userMessagesList dto)
        {
            MessageDatabase.addMessagesToServer(dto);

            var options = new PusherOptions
            {
                Cluster = "ap2",
                Encrypted = true
            };

            var pusher = new Pusher(
                "1502437",
                "d5281e60af67a5b058df",
                "89ee3c09a325b93e5ec9",
                options);

            await pusher.TriggerAsync(
                "dynamic-applications",
                "messages",
                new
                {
                    username = dto.Username,
                    message = dto.Message
                });

            return Ok();
        }
    }
}