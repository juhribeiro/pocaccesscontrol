using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Model;
using Microsoft.AspNetCore.Mvc;
using accesscontrol.Services.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using accesscontrol.ExceptionMiddleware;
using System.Linq;

namespace accesscontrol.Controllers
{
    [Route("/api/[controller]")]
    public abstract class BaseController<T> : ControllerBase where T : BaseModel
    {
        private readonly IBaseService<T> _service;

        public BaseController(IBaseService<T> service)
        {
            this._service = service;
        }

        [HttpGet("")]
        public virtual async Task<ActionResult<List<T>>> GetAsync(bool active = true)
        {
            return await this._service.ListAsync(active);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetAsync(int id)
        {
            return await this._service.GetByIdAsync(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> PostAsync([FromBody]T item)
        {
            if (this.ModelState.IsValid)
            {
                item = await this._service.AddAsync(item);
                return Created(nameof(item), new { id = item.Id });
            }

            throw new CustomException(new MessageDetails(Enums.MessageType.Error, MessagesErrorsModel(this.ModelState)));
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> PutAsync(int id, T item)
        {
            if (this.ModelState.IsValid)
            {
                await this._service.UpdateAsync(id, item);
                return NoContent();
            }

            throw new CustomException(new MessageDetails(Enums.MessageType.Error, MessagesErrorsModel(this.ModelState)));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            await this._service.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Execute get errors model
        /// </summary>
        protected static string MessagesErrorsModel(ModelStateDictionary modelstate)
        {
            if (modelstate is null)
            {
                throw new CustomException(new MessageDetails(Enums.MessageType.Error, $"Desculpe, mas o objeto passado é inválido"));
            }

            string messages = string.Join("; ", modelstate.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            return messages;
        }
    }
}