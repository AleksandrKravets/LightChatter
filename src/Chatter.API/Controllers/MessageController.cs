using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Messages;
using Chatter.WebUI.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IHubContext<ChatHub> _chat;

        public MessageController(IMessageService messageService, IHubContext<ChatHub> chat)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
            _chat = chat ?? throw new ArgumentNullException(nameof(chat));
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _messageService.GetAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _messageService.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageModel model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest();

            var createdMessage = await _messageService.CreateAsync( model);

            await _chat.Clients.All.SendAsync("ReceivedMessage", createdMessage);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _messageService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody]UpdateMessageModel model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest();

            await _messageService.UpdateAsync(id, model);

            return Ok();
        }
    }
}
