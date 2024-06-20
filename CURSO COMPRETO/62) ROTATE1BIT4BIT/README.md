# ROTATE1BIT4BIT
Esse código em C# demonstra um programa simples que carrega imagens de arquivos, aplica uma série de operações de rotação e espelhamento nelas usando diferentes tipos da enumeração `RotateFlipType`, e salva as imagens resultantes em novos arquivos PNG.

## Explicação Passo a Passo:
1. **Método `load(string name)`**:
   - Este método utiliza um bloco `using` para garantir que o recurso de `Stream` (nesse caso, um arquivo) seja corretamente fechado após seu uso.
   - Ele abre um arquivo de imagem especificado pelo nome (`name`), carrega-o como um objeto `Bitmap` usando `Bitmap.FromStream(stream)`, e retorna esse bitmap.
   - Se ocorrer algum erro ao abrir o arquivo, ele será capturado no bloco `catch` e uma mensagem de exceção será exibida.

2. **Método `Main()`**:
   - O método principal inicia iterando sobre todos os nomes de enumeração na enumeração `RotateFlipType`. Essa enumeração define diferentes tipos de rotação e espelhamento que podem ser aplicados a um objeto `Bitmap`.
   - Para cada tipo de rotação, o programa tenta carregar duas imagens diferentes (`1bit.png` e `4bit.png`), rotaciona cada uma delas de acordo com o tipo atual, e salva as imagens resultantes com um nome de arquivo que inclui o tipo de rotação.

3. **Iteração sobre os Tipos de Rotação**:
   - Para cada tipo de rotação (`RotateFlipType`), o programa carrega as imagens `1bit.png` e `4bit.png`.
   - Aplica a operação de rotação usando `result.RotateFlip(type)`.
   - Se ocorrer uma exceção durante o processo de carregamento, rotação ou salvamento da imagem, a exceção é capturada, exibida na console, e o objeto `Bitmap` (`result`) é descartado para liberar recursos.

4. **Finalização do Programa**:
   - Ao concluir todas as operações de rotação e salvamento para todos os tipos de rotação definidos, o programa exibe "done!" na console, indicando que todas as operações foram concluídas com sucesso.

## Considerações Finais:
- **Tratamento de Exceções**: O código utiliza blocos `try-catch` para lidar com exceções que possam ocorrer ao carregar, manipular ou salvar as imagens. Isso é importante para garantir que o programa não quebre abruptamente em caso de erros.

- **Descarte de Recursos**: O método `Dispose()` é chamado nos objetos `Bitmap` (`result`) após seu uso para liberar recursos imediatamente, uma prática recomendada quando se trabalha com recursos não gerenciados como arquivos de imagem.

- **Manipulação de Imagens**: A capacidade de aplicar diferentes tipos de rotação e espelhamento (`RotateFlipType`) permite criar versões modificadas das imagens originais, o que pode ser útil em processos de pré-processamento de imagens em aplicações de visão computacional, processamento de imagem, entre outros.

Este código exemplifica bem como manipular imagens em C# usando funcionalidades básicas de carregamento, manipulação e salvamento, mostrando também boas práticas de gerenciamento de recursos e tratamento de exceções.