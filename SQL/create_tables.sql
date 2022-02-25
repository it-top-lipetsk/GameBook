CREATE TABLE tab_genres
(
    id    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    genre TEXT    NOT NULL
);

CREATE TABLE tab_games
(
    id       INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    name     TEXT    NOT NULL,
    id_genre INTEGER NOT NULL,
    FOREIGN KEY (id_genre) REFERENCES tab_genres (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);


INSERT INTO tab_genres (genre)
VALUES ('strategy'),
       ('actionRPG');

INSERT INTO tab_games (name, id_genre)
VALUES ('Starcraft', 1),
       ('Diablo', 2);
