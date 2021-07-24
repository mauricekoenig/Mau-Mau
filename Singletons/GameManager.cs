


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MK.MauMau
{
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public event Action OnTopCardChanged;

        [SerializeField] private Transform _local;
        [SerializeField] private Transform _remote;
        [SerializeField] private Transform _middle;
        [SerializeField] private GameObject _template;
        [SerializeField] private GameObject _back;
        [SerializeField] private List<Card> _list = new List<Card>();
        [SerializeField] [Range(0.1f, 1f)] private float speed;
        [SerializeField] private int giveEach;

        public Deck deck;
        public Card TopCard { get; set; }
        public ColorProperty WishedColor { get; set; }
        public Player CurrentPlayer { get; set; }

        private void Awake() {

            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }
        private void Start() {

            StartCoroutine("StartGame");
        }
        public void Subscribe (Action action) {

            OnTopCardChanged += action;
        }
        public void Unsubscribe (Action action) {
            OnTopCardChanged -= action;
        }
        public IEnumerator StartGame() {

            _list = GetCopy(deck);
            _list = Shuffle(_list);

            var players = new Player[2] { Player.Local, Player.Remote };
            var startPlayer = players[new System.Random().Next(0, players.Length)];
            CurrentPlayer = startPlayer;

            for (int i = 0; i < (giveEach * 2); i++) {

                if (CurrentPlayer == Player.Local) {

                    var card = CreateEmptyCard(Location.Local);
                    card.Construct(_list[0]);
                    _list.RemoveAt(0);
                    CurrentPlayer = Player.Remote;
                }

                else if (CurrentPlayer == Player.Remote) {

                    var card = CreateEmptyCard(Location.Remote);
                    //card.Construct(_list[0]);
                    //_list.RemoveAt(0);
                    CurrentPlayer = Player.Local;
                }

                yield return new WaitForSeconds(speed);
            }

            var info = CreateEmptyCard(Location.Middle);
            info.Construct(_list[0]);
            TopCard = _list[0];
            _list.RemoveAt(0);

        }
        public List<Card> Shuffle (List<Card> list) {

            list = list.OrderBy(x => Guid.NewGuid()).ToList();
            return list;
        }
        public Info CreateEmptyCard (Location location) {

            switch (location) {

                case Location.Local:
                    var localCard = Instantiate(_template, _local);
                    return localCard.GetComponent<Info>();

                case Location.Remote:
                    var remoteCard = Instantiate(_back, _remote);
                    return null;

                case Location.Middle:
                    var middleCard = Instantiate(_template, _middle);
                    return middleCard.GetComponent<Info>();

                default:
                    return null;
            }
        }
        private List<Card> GetCopy (Deck deck) {

            var list = new List<Card>();

            for (int i = 0; i < deck.Cards.Count; i++) {
                list.Add(deck.Cards[i]);
            }

            return list;
        }
    }
}