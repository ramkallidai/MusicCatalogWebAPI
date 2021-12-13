using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musicalog.Api.Services;
using Musicalog.Domain.Entities;

namespace Musicalog.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet("GetAlbums")]
        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            try
            {
                return await _albumService.GetAlbumsAsync();
            }
            catch (Exception ex)
            {
                //Log the exception
                return null;
            }
        }
        [HttpPost("NewAlbum")]
        public async Task<IActionResult> CreateAlbum([FromBody]Album album)
        {
            try
            {
                if (album == null)
                {
                    return BadRequest("album object is null");
                }
                if (!ModelState.IsValid)
                {
                    //log if you need
                    return BadRequest("Invalid model object");
                }
                await _albumService.CreateAlbumAsync(album);
                return Ok();
            }
            catch (Exception ex)
            {
                //log if you need

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost("AmendAlbum")]
        public async Task<IActionResult> UpdateAlbum([FromBody]Album album)
        {
            try
            {
                if (album == null)
                {
                    return BadRequest("album object is null");
                }
                if (!ModelState.IsValid)
                {
                    //log if you need
                    return BadRequest("Invalid model object");
                }
                await _albumService.UpdateAlbumAsync(album);
                return Ok();
            }
            catch (Exception ex)
            {
                //log if you need

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost("RemoveAlbum")]
        public async Task<IActionResult> DeleteAlbum([FromBody]Album album)
        {
            try
            {
                if (album == null)
                {
                    return BadRequest("album object is null");
                }
                if (!ModelState.IsValid)
                {
                    //log if you need
                    return BadRequest("Invalid model object");
                }
                await _albumService.DeleteAlbumAsync(album);
                return Ok();
            }
            catch (Exception ex)
            {
                //log if you need

                return StatusCode(500, "Internal server error");
            }
        }

    }
}