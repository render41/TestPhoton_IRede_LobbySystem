## **Connection Test**

1. **Namespace e Classe:** O código está contido no namespace "Settings" e define uma classe chamada "ConnectionTest".
  
2. **Método `OnConnectedToMaster()`:**
  
  - Esse método é chamado quando a conexão com o servidor Photon é estabelecida com sucesso.
  - Ele simplesmente exibe a mensagem "Connect to Server" no console usando `print()`.
3. **Método `OnDisconnected(DisconnectCause cause)`:**
  
  - Esse método é chamado quando ocorre uma desconexão do servidor.
  - Ele exibe uma mensagem no console que informa a causa da desconexão. A variável `cause` contém informações sobre o motivo da desconexão.

## **Panel Manager**

1. **Namespace e Classe:** O código está contido no namespace "Settings" e define uma classe chamada "PanelManager".
  
2. **Método `SetActivePanels(GameObject activePanel, GameObject inactivePanel)`:**
  
  - Esse método público é usado para alternar a visibilidade entre dois painéis na cena.
  - Ele recebe dois parâmetros do tipo `GameObject`:
    - `activePanel`: O painel que deve ser ativado (tornado visível).
    - `inactivePanel`: O painel que deve ser desativado (tornado invisível).
  - Dentro do método, o painel ativo é ativado usando `activePanel.SetActive(true)`, tornando-o visível.
  - O painel inativo é desativado usando `inactivePanel.SetActive(false)`, tornando-o invisível.
