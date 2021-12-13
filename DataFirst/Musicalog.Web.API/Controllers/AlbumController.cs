using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musicalog.Domain.Models;
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
        [HttpGet("GetAlbumsByArtist")]
        public async Task<IEnumerable<Album>> GetAlbumsByArtistAsync(string artist)
        {
            try
            {
                return await _albumRepository.GetAllAlbumsByArtistAsync(artist);
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
                album.AlbumId = Guid.NewGuid();
                await _albumRepository.CreateAlbumAsync(album);
                return Ok();
            }
            catch (Exception ex)
            {
                //log if you need

                //return StatusCode(500, ex.InnerException.StackTrace.ToString());
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("AmendAlbum")]
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
                Album a = await _albumRepository.GetAlbumByIdAsync(album.AlbumId);
                if (a != null)
                {
                    a.MediaType = album.MediaType;
                    a.Stock = album.Stock;
                    a.Artist = album.Artist;
                    a.Title = album.Title;
                    await _albumRepository.UpdateAlbumAsync(a);
                }
                //return Ok();
                return StatusCode(200,a.AlbumId);

            }
            catch (Exception ex)
            {
                //log if you need

                return StatusCode(500, ex.Message);
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

                var a = await _albumRepository.GetAlbumByIdAsync(album.AlbumId);
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