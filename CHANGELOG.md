# Changelog

## 1.1.8.3-cOLa
- Fix: el servidor podía caerse (.NET "Unhandled exception. System.NullReferenceException") al salir un jugador. Las lambdas async pasadas a `Server.NextFrameAsync` y `AddTimer` eran async void, así que una excepción dentro abortaba todo el proceso. Ahora pasan por `Helper.FireAndForget`, que registra la excepción en la consola en vez de tumbar el servidor.

## 1.1.8.2-cOLa
- Rendimiento: las listas de comandos del config se procesan una vez y no en cada mensaje de chat (el hook de chat las procesaba las tres en cada mensaje).
- Rendimiento: `GetPlayersController` recorre los slots de jugador en vez de todas las entidades del mapa.
- Rendimiento: el hook de `SetSoundEventParam` (se ejecuta en cada sonido) ya no comprueba el sistema operativo en cada llamada.

## 1.1.8.1-cOLa
- Fix para CounterStrikeSharp 1.0.375 (KHook): el hook de `CSoundOpGameSystem_SetSoundEventParamFunc_2` pasaba un `uint` con `SetParam` a un parametro declarado como `IntPtr`, lo que lanzaba "Hook value is not numeric" en cada sonido. Ahora se pasa como `IntPtr`.
- Anadido workflow de GitHub Actions (`.github/workflows/build.yml`) que compila y publica una release al subir una version nueva.

## 1.1.8-cOLa
- Version anterior del fork cOLa-TeaM.
