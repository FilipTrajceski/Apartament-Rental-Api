using S_T.Apartaments.Entities.Enums;

namespace S_T.Apartaments.Entities.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public RoomSize RoomSize {  get; set; }
        public RoomStatus RoomStatus {  get; set; }
    }
}
