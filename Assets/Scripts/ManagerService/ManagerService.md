## **Connect to Server** 

1. **Importações de Bibliotecas:** bibliotecas necessárias para o funcionamento do Photon PUN e outros componentes.
  
2. **Namespace e Classe:** O código está contido dentro do namespace "ManagerService" e define uma classe chamada "ConnectToServer". Essa classe herda de `MonoBehaviourPunCallbacks`, que é uma classe fornecida pelo Photon PUN para lidar com eventos de callback relacionados à rede.
  
3. **Variáveis Serializadas:** variáveis `usernameInputField`, `buttonText` e `sceneName` são marcadas como `SerializeField`, o que permite que elas sejam visíveis e configuráveis no Inspector. Elas são referências a um campo de entrada de texto (para inserir o nome de usuário), um campo de texto (para exibir o texto do botão) e o nome da cena que será carregada após uma conexão bem-sucedida.
  
4. **Variável `_isConnecting`:** variável booleana privada `_isConnecting` é usada para rastrear se uma tentativa de conexão está em andamento.
  
5. **Método `Update()`:** verifica se a tecla Enter foi pressionada e se não há uma tentativa de conexão em andamento (`_isConnecting`). Se ambos os critérios forem atendidos, chama o método `OnClickConnect()`.
  
6. **Método `OnClickConnect()`:** verifica se o campo de entrada de nome de usuário tem pelo menos um caractere. Em seguida, define o apelido (nome de usuário) do jogador no Photon usando o texto inserido no campo de entrada. Ele também atualiza o texto do botão para indicar que uma conexão está sendo tentada e, finalmente, chama `PhotonNetwork.ConnectUsingSettings()` para iniciar a tentativa de conexão ao servidor Photon.
  
7. **Método `OnConnectedToMaster()`:** é chamado quando a conexão com o servidor Photon é estabelecida com sucesso. Ele carrega a cena especificada em `sceneName`, que geralmente é a cena do lobby do jogo.
  
8. **Método `OnDisconnected()`:** Esse método é chamado quando ocorre uma desconexão do servidor. Ele redefine a variável `_isConnecting` para `false`, atualiza o texto do botão para "Connect" (Conectar) após a desconexão e exibe uma mensagem de aviso no console com a causa da desconexão.
  

## **Lobby Manager**

1. **Importações de Bibliotecas:** contém as bibliotecas necessárias, incluindo o Photon PUN, classes relacionadas a configurações e componentes do Unity.
  
2. **Namespace e Classe:** O código está contido no namespace "ManagerService" e define uma classe chamada "LobbyManager". Essa classe herda de `MonoBehaviourPunCallbacks`, que é uma classe fornecida pelo Photon PUN para lidar com eventos de callback relacionados à rede.
  
3. **Variáveis Serializadas:** elas referênciam elementos de interface de usuário no Unity, como texto, campos de entrada e painéis. Elas permitem configurar esses elementos no Inspector.
  
4. **Variável `_panelManager`:** variável privada `_panelManager` é declarada para gerenciar os painéis ativos na cena. Um objeto do tipo `PanelManager` é adicionado a um objeto `panels` (provavelmente outro GameObject), que será responsável pelo gerenciamento dos painéis.
  
5. **Métodos Mono `Awake()`, `Start()` e `Update()`:**
  
  - `Awake()`: nele, um novo componente `PanelManager` é criado e adicionado ao objeto `panels`. Além disso, `PhotonNetwork.AutomaticallySyncScene` é definido como `true`, o que permite que o Photon sincronize automaticamente as cenas entre os jogadores.
  - `Start()`: o nome do jogador é exibido na interface e o jogador tenta se conectar ao lobby do Photon.
  - `Update()`: verifica se a tecla Enter foi pressionada e, se sim, chama o método `OnClickCreateRoom()`.
6. **Métodos de Callback do Photon:**
  
  - `OnConnectedToMaster()`: neste caso, é usado quando o jogador tenta se juntar ao lobby.
  - `OnJoinedRoom()`: isso ativa o painel da sala e exibe o nome da sala atual.
  - `OnLeftRoom()`: redefine o gerenciamento de painéis para o estado do lobby.
7. **Métodos Extras:**
  
  - `JoinRoom(string roomName)`: solicita ao Photon para juntar-se a uma sala específica pelo nome.
  - `OnClickCreateRoom()`: ação de botão que verifica se o nome da sala não está vazio e se o jogador está conectado antes de criar a sala com opções específicas.
  - `OnClickLeaveRoom()`: ação de botão que, chamado quando o jogador tenta sair da sala atual.
