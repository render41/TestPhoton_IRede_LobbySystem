## **Chat System**

1. **Importações de Bibliotecas:** importa as bibliotecas necessárias, incluindo o Photon PUN e outras bibliotecas relacionadas.
  
2. **Namespace e Classe:** o código está contido no namespace "ManagerService.ChatSystem" e define uma classe chamada "ChatMessageManager". Essa classe herda de `MonoBehaviourPunCallbacks`, que é uma classe fornecida pelo Photon PUN para lidar com eventos de callback relacionados à rede.
  
3. **Variáveis Serializadas:**
  
  - `messageInputField`: referência a um campo de entrada de texto onde os jogadores digitam suas mensagens.
  - `chatContent`: referência a um componente TextMeshProUGUI que exibirá o conteúdo do chat.
  - `maximumMessages`: número máximo de mensagens que serão exibidas no chat.
4. **Variáveis Privadas:**
  
  - `_photonView`: referência ao componente `PhotonView` que permite sincronizar dados entre os jogadores.
  - `_messages`: lista que armazena as mensagens do chat.
  - `_buildDelay`: faz um atraso usado para controlar a atualização do conteúdo do chat.
5. **Método `Start()`:** Obtém a referência ao `PhotonView` anexado ao objeto.
  
6. **Método `Update()`:**
  
  - Verifica se a tecla Enter foi pressionada e, em caso afirmativo, chama o método `SubmitMessageChat()`.
  - Chama o método `UpdateChat()` para atualizar o conteúdo do chat.
7. **Método `AddMessageRPC(string message)`:**
  
  - Um método RPC (Remote Procedure Call) que adiciona uma mensagem à lista `_messages`. Este método será chamado remotamente para manter a sincronização entre os jogadores.
8. **Método `SendMessageChat(string message)`:**
  
  - Cria uma nova mensagem formatada com o nome de usuário do jogador e a mensagem enviada.
  - Chama um RPC para adicionar a mensagem à lista `_messages`.
9. **Método `SubmitMessageChat()`:**
  
  - Verifica se a mensagem está em branco. Se estiver, limpa o campo de entrada e não realiza a ação.
  - Caso contrário, envia a mensagem chamando o método `SendMessageChat()`, limpa o campo de entrada e o ativa.
10. **Método `BuildChatContents()`:**
  
  - Constrói o conteúdo do chat concatenando todas as mensagens da lista `_messages`.
11. **Método `UpdateChat()`:**
  
  - Verifica se o jogador está em uma sala do Photon.
  - Se estiver em uma sala:
  - Define o número máximo de linhas visíveis para o conteúdo do chat.
  - Remove mensagens antigas se a lista `_messages` exceder o limite especificado.
  - Verifica o tempo para evitar atualizações frequentes no conteúdo do chat.
  - Chama `BuildChatContents()` para atualizar o chat.
  - Se não estiver em uma sala, limpa as mensagens e o conteúdo do chat.
