// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(message) {
    return prompt(message, 'Type anything here');
  }
export function importCss() {
  var link = document.createElement( "link" );
  link.href = "./individual-user-module.css";
  link.type = "text/css";
  link.rel = "stylesheet";
  link.media = "screen,print";
  document.getElementsByTagNam( "head" )[0].appendChild( link );

  link = document.createElement( "link" );
  link.href = "./individualusermodule.styles.css";
  link.type = "text/css";
  link.rel = "stylesheet";
  link.media = "screen,print";
  document.getElementsByTagNam( "head" )[0].appendChild( link );
}

  