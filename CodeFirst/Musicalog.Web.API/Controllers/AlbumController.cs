using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musicalog.Domain.Entities;
using Musicalog.Api.EFCore.Interfaces;
using Musicalog.Api.EFCore.Repositories;
namespace Musicalog.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        readonly IAlbumRepository _albumRepository;

        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }
        [HttpGet("GetAlbums")]
        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            try
            {
                return await _albumRepository.GetAllAlbumsAsync();
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
                await _albumRepository.CreateAlbumAsync(album);
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
                var a = await _albumRepository.GetAlbumByIdAsync(album.AlbumID);
                if (a != null)
                {
                    await _albumRepository.UpdateAlbumAsync(album);
                }
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

                var a = await _albumRepository.GetAlbumByIdAsync(album.AlbumID);
                await _albumRepository.DeleteAlbumAsync(a);
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