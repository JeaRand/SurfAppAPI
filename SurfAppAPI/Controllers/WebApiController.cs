using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfAppAPI.Models;
namespace WebAPISurf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly SurfBoardAppDataContext _dbcontext;
        public WeatherForecastController(SurfBoardAppDataContext _context)
        {
            _dbcontext = _context;
        }



        [HttpGet]
        [Route("Board")]
        public async Task<IActionResult> GetBoard()
        {
            try
            {
                List<Board> listBoards = _dbcontext.Boards.ToList();
                if (listBoards != null)
                {
                    return Ok(listBoards);
                }
                return Ok("There is not any users in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        [Route("Board")]
        public async Task<IActionResult> CreateBoard([FromBody] Board board)
        {
            try
            {
                if (board != null)
                {
                    _dbcontext.Boards.Add(board);
                    _dbcontext.SaveChanges();
                    return Ok("Board created successfully");
                }
                return BadRequest("Board object is null");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteBoard(int Id)
        {
            if (_dbcontext.Boards == null)
            {
                return NotFound();
            }
            var boards = await _dbcontext.Boards.FindAsync(Id);
            if (boards == null)
            {
                return NotFound();
            }



            _dbcontext.Boards.Remove(boards);
            await _dbcontext.SaveChangesAsync();



            return NoContent();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Board>> GetTodoItem(long id)
        {
            var todoItem = await _dbcontext.Boards.FindAsync(id);



            if (todoItem == null)
            {
                return NotFound();
            }



            return boardDTO(todoItem);
        }



        private static Board boardDTO(Board boardItem) =>
        new Board
        {
            Id = boardItem.Id,
            Name = boardItem.Name
        };



        private bool BoardExists(long id)
        {
            return _dbcontext.Boards.Any(e => e.Id == id);
        }



        [HttpPut("{Id}")]
        public async Task<IActionResult> PutBoard(int Id, Board board)
        {
            if (Id != board.Id)
            {
                return BadRequest();
            }



            _dbcontext.Entry(board).State = EntityState.Modified;



            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }



            return NoContent();
        }



    }
}