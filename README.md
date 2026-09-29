# 🎮 OFFICE QUEST

### 🏢 Escape the office. Solve the puzzles. Survive the nightmare.

**Office Quest** es un videojuego de **puzzles, suspense y terror** desarrollado en **Unity** como **Trabajo de Fin de Grado (TFG) de Desarrollo de Aplicaciones Multiplataforma (DAM)**.

El jugador se pone en la piel de un oficinista atrapado en una pesadilla dentro de su propio lugar de trabajo. Para escapar tendrá que resolver diferentes pruebas, descubrir un código secreto, enfrentarse a enemigos y sobrevivir a una serie de situaciones cada vez más inquietantes.

> ⏱️ **Tienes 1000 segundos para escapar. ¿Serás capaz de conseguirlo?**

---

## 🕹️ ¿QUÉ ES OFFICE QUEST?

Tras una dura jornada de trabajo, el protagonista se queda dormido y comienza una horrible pesadilla.

Al despertar, se encuentra completamente solo en la oficina.

La única forma de escapar es superar diferentes pruebas repartidas por el escenario, conseguir los dígitos de un código secreto y utilizarlo para obtener la llave de la puerta.

Pero la oficina esconde mucho más de lo que parece...

A medida que avanzas, la situación se vuelve cada vez más peligrosa, hasta terminar atravesando un oscuro pasillo, enfrentándote a tu propio jefe convertido en un enemigo y llegando a las misteriosas **Backrooms**.

---

## 🧩 CARACTERÍSTICAS

### 💻 Minijuegos

Los ordenadores repartidos por la oficina permiten acceder a diferentes pruebas que tendrás que superar para avanzar:

* 🔤 **El Ahorcado** — descubre las palabras ocultas antes de completar el dibujo.
* 🔢 **Adivina mi Número** — encuentra los números secretos siguiendo las pistas.
* ❓ **Preguntados** — responde preguntas de diferentes categorías y supera sus inquietantes preguntas finales.

Cada minijuego completado proporciona un dígito necesario para descubrir el código de la caja fuerte.

---

### 🔐 Código secreto

El código de la caja fuerte se genera aleatoriamente al comenzar cada partida.

Los dígitos obtenidos mediante los minijuegos permiten al jugador descubrir el código y conseguir la llave necesaria para escapar de la oficina.

El orden en el que se obtienen los dígitos no afecta a la combinación final.

---

### ⏱️ Cuenta atrás

La partida comienza con **1000 segundos**.

El tiempo restante se mantiene durante las diferentes escenas del juego, por lo que cada decisión cuenta.

Si el contador llega a cero...

> 💀 **La partida termina.**

---

### 🌑 La oficina se queda a oscuras

Después de completar dos minijuegos, la oficina cambia por completo.

Las luces se apagan, los ordenadores dejan de funcionar y el jugador tendrá que encontrar un interruptor para recuperar la electricidad.

Pero antes tendrá que adentrarse en un pequeño almacén...

---

### ⚔️ Minijuego 2D

Tras escapar de la oficina, el jugador llega al despacho del jefe y se encuentra con un nuevo desafío.

Un minijuego de plataformas en 2D en el que tendrá que enfrentarse a diferentes enemigos utilizando cuchillos.

Entre los enemigos encontramos:

* 🐺 Lobos
* 🧟 Zombies
* 🐺 Un jefe final convertido en lobo

El boss final cuenta con una mayor cantidad de vida y un ataque especial mediante saltos.

---

### 🟨 BACKROOMS

Cuando parece que finalmente has conseguido escapar...

El ascensor falla.

El jugador termina en las **Backrooms**, un laberinto de pasillos amarillentos y aparentemente interminables.

Para escapar será necesario encontrar **5 muñecos** escondidos por el escenario y localizar un segundo ascensor.

Pero no estás solo.

### 👻 Phantom Foxy

Un animatrónico conocido como **Phantom Foxy** patrulla las Backrooms.

Foxy cuenta con un sistema de detección basado en:

* 👁️ Radio de visión
* 📐 Ángulo de visión
* 🏃 Persecución del jugador
* 🧭 Patrullaje mediante puntos de destino
* ⚡ Aumento de velocidad durante la persecución

Si consigue alcanzarte...

> ☠️ **Jumpscare. Partida terminada.**

---

## 💾 SISTEMA DE PUNTUACIÓN

Office Quest incorpora un sistema de puntuación basado en el **tiempo restante al completar la partida**.

El nombre del jugador y su puntuación se almacenan localmente, permitiendo comparar las mejores marcas y fomentar un estilo de juego basado en el **speedrun**.

---

## 🛠️ TECNOLOGÍAS

| Tecnología                | Uso                                |
| ------------------------- | ---------------------------------- |
| 🎮 **Unity 2021.3.15f1**  | Motor de desarrollo del videojuego |
| 💻 **C#**                 | Programación y lógica del juego    |
| 🧩 **Visual Studio 2022** | Desarrollo de scripts              |
| 🎨 **Blender**            | Edición y adaptación de modelos 3D |
| 🔀 **Git**                | Control de versiones               |

El proyecto combina escenas **3D y 2D**, diferentes sistemas de interacción, animaciones, iluminación, almacenamiento de datos y lógica de enemigos.

---

## 🧠 ASPECTOS DESTACADOS DEL DESARROLLO

Durante el desarrollo se trabajó especialmente en diferentes sistemas de Unity y programación con C#:

* 🎬 Gestión de múltiples escenas.
* 💾 Persistencia de información entre escenas.
* 📍 Guardado de la posición del jugador.
* ⏱️ Sistema de cuenta atrás global.
* 🎲 Generación de códigos aleatorios.
* 🖥️ Interacción con objetos mediante `Colliders` y `Triggers`.
* 💡 Control dinámico de iluminación.
* ❤️ Sistema de vida y daño.
* 🤖 IA básica para enemigos.
* 👁️ Detección del jugador mediante distancia y campo de visión.
* 🏃 Sistemas de persecución.
* 👻 Jumpscares y cámaras especiales.
* 🏆 Sistema de puntuaciones y almacenamiento local.

---

## 💻 REQUISITOS MÍNIMOS

| Requisito             | Mínimo               |
| --------------------- | -------------------- |
| 🖥️ Sistema operativo | Windows 7 o superior |
| 🧠 RAM                | 8 GB                 |
| ⚙️ Procesador         | Intel i3 2.5 GHz     |
| 💾 Almacenamiento     | 400 MB               |

---

## 🎓 TRABAJO DE FIN DE GRADO

**Office Quest** fue desarrollado como proyecto final del **CFGS de Desarrollo de Aplicaciones Multiplataforma (DAM)**.

El proyecto fue realizado por:

### 👨‍💻 Mario Suárez Ortiz

### 👨‍💻 Marcos Sánchez-Cruzado Rovira

El desarrollo se realizó de forma colaborativa, dividiendo las tareas entre programación, escenas, animaciones, iluminación, minijuegos, sistemas de juego y desarrollo de enemigos.

---

## 🚀 POSIBLES MEJORAS

Entre las mejoras planteadas para futuras versiones se encuentran:

* 🌐 Ranking online con jugadores de todo el mundo.
* 🌍 Sistema de selección de idioma.
* 🧩 Nuevos niveles y dificultades.
* 📱 Versión para dispositivos móviles.
* 🎮 Compatibilidad con mandos.
* 👥 Posible modo multijugador.

---

## 📚 SOBRE EL PROYECTO

Este proyecto supuso una primera experiencia significativa en el desarrollo de un videojuego 3D con Unity, combinando los conocimientos adquiridos durante el ciclo formativo con el aprendizaje autodidacta de nuevas funcionalidades del motor.

El desarrollo se realizó durante aproximadamente 3 meses, aprendiendo mediante documentación, tutoriales y experimentación con Unity y C#.

El resultado es un videojuego que combina escape room, puzzles, plataformas, suspense y terror en una única aventura.

<p align="center">

🎮 OFFICE QUEST

🏢 Escape the office. Survive the nightmare.

</p>
