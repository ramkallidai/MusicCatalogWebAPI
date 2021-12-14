using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musicalog.Domain.Models;
using Musicalog.Api.EFCore.Interfaces;
using Musicalog.Api.EFCore.Repositories;
using AutoMapper;
using Musicalog.Web.API.DTO;

namespace Musicalog.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAlbums")]
        public async Task<IActionResult> GetAlbumsAsync()
        {
            try
            {
                var list = await _albumRepository.GetAllAlbumsAsync();

                var albums = new List<AlbumDTO>();
                if (list != null)
                {
                    albums = _mapper.Map<List<AlbumDTO>>(list);
                }
                //return StatusCode(200, list);
                return StatusCode(200, albums);
                //return albums;
                // return list;
            }
            catch (Exception ex)
            {
                //Log the exception
                //return null;
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetAlbumsByArtist")]
        public async Task<IEnumerable<Album>> GetAlbumsByArtistAsync(Guid artist)
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