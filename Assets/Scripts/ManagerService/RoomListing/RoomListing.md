## **Room Listing**

1. **Namespace e Classe:** código está contido no namespace "ManagerService.RoomListing" e define uma classe chamada "RoomListing". Essa classe herda de `MonoBehaviourPunCallbacks`, que é uma classe fornecida pelo Photon PUN para lidar com eventos de callback relacionados à rede.
  
2. **Variáveis Serializadas:**
  
  - `content`: Uma referência a um transform que atuará como recipiente pai para os itens de lista de salas.
  - `roomItemPrefab`: Uma referência ao prefab que será instanciado para representar cada item de sala na lista.
3. **Variáveis Privadas:**
  
  - `_roomItemsList`: Uma lista de instâncias de `RoomItemList`, que são os objetos que representam as salas na lista.
  - `_timeBetweenUpdates`: O intervalo de tempo entre as atualizações da lista de salas.
  - `_nextUpdateTime`: O próximo tempo esperado para atualizar a lista de salas.
4. **Método `OnRoomListUpdate(List<RoomInfo> roomList)`:**
  
  - Verifica se é hora de atualizar com base no intervalo definido em `_timeBetweenUpdates`.
  - Limpa os itens da lista de salas chamando `ClearRoomItems()`.
  - Itera sobre a lista de informações de sala e chama `AddRooms()` para adicionar cada sala.
5. **Método `ClearRoomItems()`:**
  
  - Itera sobre os itens da lista `_roomItemsList` e destroi cada item.
  - Limpa a lista `_roomItemsList`.
6. **Método `AddRooms(RoomInfo room)`:**
  
  - Instancia o prefab `roomItemPrefab` como um novo item de sala dentro do transform `content`.
  - Configura as informações da sala no item de sala usando o método `SetRoomName()` do `RoomItemList`.
  - Adiciona o item de sala à lista `_roomItemsList`.

## **Room Item List**

1. **Namespace e Classe:** O código está contido no namespace "ManagerService.RoomListing" e define uma classe chamada "RoomItemList".
  
2. **Variáveis Serializadas:**
  
  - `roomName`: Uma referência a um componente TextMeshProUGUI onde o nome da sala será exibido.
3. **Variável Privada:**
  
  - `_lobbyManager`: Uma referência a um objeto `LobbyManager`, que é usado para interagir com a lógica do lobby.
4. **Propriedade Pública `RoomInfo`:**
  
  - Declara uma propriedade de leitura `RoomInfo` que representa as informações da sala associada a este item.
5. **Método `Start()`:**
  
  - Obtém uma referência ao `LobbyManager` na cena usando `FindObjectOfType`.
6. **Método `SetRoomName(RoomInfo roomInfo)`:**
  
  - Esse método é usado para definir as informações da sala neste item.
  - Ele recebe um objeto `RoomInfo` como argumento e atribui esse objeto à propriedade `RoomInfo`.
  - Define o texto do nome da sala no componente `TextMeshProUGUI` (usando `roomName.text`) com base no nome da sala do objeto `RoomInfo`.
7. **Método `OnClickItem()`:**
  
  - Esse método é chamado quando o item da sala é clicado.
  - Chama o método `JoinRoom()` do `_lobbyManager`, passando o nome da sala como argumento, para que o jogador possa entrar na sala.
