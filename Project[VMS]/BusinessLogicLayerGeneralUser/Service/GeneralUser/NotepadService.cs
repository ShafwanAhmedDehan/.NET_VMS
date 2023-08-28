using AutoMapper;
using BusinessLogicLayerGeneralUser.DTO;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerGeneralUser.Service.GeneralUser
{
    public class NotepadService
    {
        public static bool CreateNote(NotePadDTO noteValue)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NotePadDTO, NotePad>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<NotePad>(noteValue);
            return DataAccessPanel.NotePadControl().Create(conv);
        }

        public static List<NotePadDTO> ShowNotepad(int id)
        {
            var data = (from n in DataAccessPanel.NotePadControl().Get()
                        where n.UID == id
                        select new NotePadDTO
                        {
                             id = n.id,
                            Notes = n.Notes,
                            
                        }).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NotePad, NotePadDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<List<NotePadDTO>>(data);
            return convertedValue;
        }

        public static bool DeleteNote(int id)
        {
            return DataAccessPanel.NotePadControl().Delete(id);
        }
    }
}
