# RENDERERTEST20
Este código em C# demonstra uma aplicação Windows Forms chamada `RendererTest` que permite selecionar diferentes tipos de controles do sistema de renderização visual (`VisualStyles`). Ele utiliza a classe `ButtonRenderer` para desenhar botões em diferentes estados em um formulário.

## Estrutura da Aplicação:
1. **Namespace e Classe Principal (`RendererTest`)**:
   - A aplicação está contida no namespace `MonoCHelloWorld`.
   - A classe `RendererTest` herda da classe `Form` e serve como o formulário principal da aplicação.

2. **Método `Main()`**:
   - O método `Main()` é marcado com `[STAThread]`, indicando que a aplicação é de thread única com um modelo de apartamento.
   - Configuração inicial da aplicação:
     - `Application.EnableVisualStyles()`: Habilita estilos visuais para aplicativos que suportam temas.
     - `Application.SetCompatibleTextRenderingDefault(false)`: Desabilita o uso padrão de renderização de texto compatível.

3. **Componentes e Inicialização no Construtor**:
   - `comboBox1`: Um componente `ComboBox` que permite ao usuário selecionar diferentes tipos de renderização de controle.
     - Está posicionado no canto superior direito (`Location (565, 0)`) do formulário.
     - Contém uma lista de nomes de renderizadores disponíveis para seleção.

4. **Inicialização e Gerenciamento de Componentes (`InitializeComponent()` e `Dispose()`)**:
   - `InitializeComponent()`: Método gerado automaticamente pelo designer do Visual Studio. Configura visualmente o formulário e seus componentes.
   - `Dispose(bool disposing)`: Método para liberar recursos quando o formulário é descartado.

5. **Eventos e Métodos de Eventos**:
   - `comboBox1_SelectedIndexChanged(object sender, EventArgs e)`: Evento acionado quando o item selecionado no `ComboBox` é alterado.
     - Invalida o formulário (`Invalidate()`) para forçar o redesenho quando um novo item é selecionado.
   - `OnPaint(PaintEventArgs e)`: Método sobrescrito para desenhar no formulário.
     - Verifica o item selecionado no `comboBox1` e desenha o controle correspondente utilizando classes como `ButtonRenderer`.

## Funcionalidade de Renderização:
- **Desenho dos Botões**:
  - O método `OnPaint()` utiliza `Graphics` para desenhar na superfície do formulário.
  - Dependendo do item selecionado no `comboBox1` (por exemplo, "ButtonRenderer"), diferentes estados de botão são desenhados utilizando `ButtonRenderer.DrawButton()`.

- **Imagem e Fonte**:
  - Uma imagem é carregada de um arquivo específico (`accessories-character-map.png`).
  - Um objeto `Font` é criado para renderização de texto.

## Uso de `Invalidate()`:
- Sempre que o usuário seleciona um novo item no `ComboBox`, o evento `comboBox1_SelectedIndexChanged` invoca `Invalidate()`, o que força o formulário a chamar `OnPaint()` para redesenhar sua superfície com base no novo estado selecionado.

## Conclusão:
Este exemplo não apenas ilustra como usar renderizadores visuais (`VisualStyles`) para desenhar controles personalizados em aplicações Windows Forms, mas também demonstra o uso de eventos de controle (`ComboBox.SelectedIndexChanged`) e métodos de desenho personalizados (`OnPaint()`) para interações visuais dinâmicas e responsivas dentro do ambiente gráfico do Windows.