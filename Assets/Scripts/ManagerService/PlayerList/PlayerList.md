## **Player Listing Manager**

1. **Importações de Bibliotecas:** importa as bibliotecas necessárias, incluindo o Photon PUN e outras bibliotecas relacionadas.
  
2. **Namespace e Classe:** O código está contido no namespace "ManagerService.PlayerList" e define uma classe chamada "PlayerListingManager". Essa classe herda de `MonoBehaviourPunCallbacks`, que é uma classe fornecida pelo Photon PUN para lidar com eventos de callback relacionados à rede.
  
3. **Variáveis Serializadas:**
  
  - `playerListingItemPrefab`: Uma referência ao prefab que será instanciado para representar cada item de jogador na lista.
  - `contentPlayerList`: O transform que atuará como o recipiente pai para os itens da lista de jogadores.
4. **Variável Privada:**
  
  - `_listingItem`: Uma lista de instâncias de `PlayerListingItem`, que são os objetos que representam os jogadores na lista.
5. **Método `Awake()`:**
  
  - Chamado quando o objeto é inicializado.
  - Chama o método `GetCurrentRoomPlayer()` para obter os jogadores presentes na sala quando o jogador local se junta a ela.
6. **Método `GetCurrentRoomPlayer()`:**
  
  - Percorre todos os jogadores na sala atual usando `PhotonNetwork.CurrentRoom.Players`.
  - Chama o método `AddPlayerList()` para adicionar cada jogador à lista.
7. **Método `OnPlayerEnteredRoom(Player newPlayer)`:**
  
  - Chamado quando um novo jogador entra na sala.
  - Chama o método `AddPlayerList()` para adicionar o novo jogador à lista.
8. **Método `AddPlayerList(Player player)`:**
  
  - Instancia o prefab `playerListingItemPrefab` como um novo item de jogador dentro do transform `contentPlayerList`.
  - Configura as informações do jogador no item de jogador utilizando o método `SetPlayerInfo()` do `PlayerListingItem`.
  - Adiciona o item de jogador à lista `_listingItem`.
9. **Método `OnPlayerLeftRoom(Player otherPlayer)`:**
  
  - Chamado quando um jogador sai da sala.
  - Procura o índice do jogador na lista `_listingItem` com base no jogador que saiu.
  - Destroi o objeto do item de jogador e o remove da lista `_listingItem`.

## **Player Listing Item**

1. **Namespace e Classe:** o código está contido no namespace "ManagerService.PlayerList" e define uma classe chamada "PlayerListingItem".
  
2. **Variáveis Serializadas:**
  
  - `playerNameTextTMP`: uma referência a um componente TextMeshProUGUI onde o nome do jogador será exibido.
3. **Propriedade Pública `Player`:**
  
  - Declara uma propriedade de leitura `Player` que representa o jogador associado a este item.
4. **Método `SetPlayerInfo(Player player)`:**
  
  - Usado para definir as informações do jogador neste item.
  - Recebe um objeto `Player` como argumento e atribui esse jogador à propriedade `Player`.
  - Define o texto do nome do jogador no componente `TextMeshProUGUI` (usando `playerNameTextTMP.text`) com base no nome de usuário do jogador.
