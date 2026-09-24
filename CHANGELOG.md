# Changelog

## 1.1.8.1-cOLa
- Fix para CounterStrikeSharp 1.0.375 (KHook): el hook de `CSoundOpGameSystem_SetSoundEventParamFunc_2` pasaba un `uint` con `SetParam` a un parametro declarado como `IntPtr`, lo que lanzaba "Hook value is not numeric" en cada sonido. Ahora se pasa como `IntPtr`.
- Anadido workflow de GitHub Actions (`.github/workflows/build.yml`) que compila y publica una release al subir una version nueva.

## 1.1.8-cOLa
- Version anterior del fork cOLa-TeaM.
