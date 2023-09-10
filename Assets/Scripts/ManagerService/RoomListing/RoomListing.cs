using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace ManagerService.RoomListing
{
    public class RoomListing : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform content;
        [SerializeField] private RoomItemList roomItemPrefab;

        private readonly List<RoomItemList> _roomItemsList = new List<RoomItemList>();
        private readonly float _timeBetweenUpdates = 1.5f;
        private float _nextUpdateTime;
        

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            if (Time.time >= _timeBetweenUpdates)
            {
                ClearRoomItems();
                foreach (var room in roomList)
                {
                    AddRooms(room);
                }

                _nextUpdateTime = Time.time + _timeBetweenUpdates;
            }

            foreach (var room in roomList.Where(room => room.PlayerCount <= 0))
            {
                ClearRoomItems();
            }
        }

        private void ClearRoomItems()
        {
            foreach (var item in _roomItemsList)
            {
                Destroy(item.gameObject);
            }
            _roomItemsList.Clear();
        }

        private void AddRooms(RoomInfo room)
        {
            var newRoom = Instantiate(roomItemPrefab, content);
            newRoom.SetRoomName(room);
            _roomItemsList.Add(newRoom);
        }
    }
}