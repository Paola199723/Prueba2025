-- =============================================
-- SCRIPT DE CREACIÓN DE TABLAS - BlogDemo
-- =============================================

-- 1️⃣ Tabla: Users
CREATE TABLE "Users" (
    "Id" SERIAL PRIMARY KEY,
    "Username" VARCHAR(255) NOT NULL,
    "Email" VARCHAR(255) NOT NULL,
    "Password" VARCHAR(255) NOT NULL
);

-- 2️⃣ Tabla: Posts
CREATE TABLE "Posts" (
    "Id" SERIAL PRIMARY KEY,
    "Title" VARCHAR(255) NOT NULL,
    "Content" TEXT NOT NULL,
    "UserId" INT NOT NULL,
    CONSTRAINT "FK_Posts_Users_UserId"
        FOREIGN KEY ("UserId") REFERENCES "Users"("Id")
        ON DELETE CASCADE
);

-- 3️⃣ Tabla: Comments
CREATE TABLE "Comments" (
    "Id" SERIAL PRIMARY KEY,
    "Content" TEXT NOT NULL,
    "PostId" INT NOT NULL,
    "UserId" INT NOT NULL,
    CONSTRAINT "FK_Comments_Posts_PostId"
        FOREIGN KEY ("PostId") REFERENCES "Posts"("Id")
        ON DELETE CASCADE,
    CONSTRAINT "FK_Comments_Users_UserId"
        FOREIGN KEY ("UserId") REFERENCES "Users"("Id")
        ON DELETE CASCADE
);

-- 4️⃣ Tabla: Tags
CREATE TABLE "Tags" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL
);

-- 5️⃣ Tabla intermedia: PostTags (relación muchos a muchos)
CREATE TABLE "PostTag" (
    "PostId" INT NOT NULL,
    "TagId" INT NOT NULL,
    PRIMARY KEY ("PostId", "TagId"),
    CONSTRAINT "FK_PostTag_Posts_PostId"
        FOREIGN KEY ("PostId") REFERENCES "Posts"("Id")
        ON DELETE CASCADE,
    CONSTRAINT "FK_PostTag_Tags_TagId"
        FOREIGN KEY ("TagId") REFERENCES "Tags"("Id")
        ON DELETE CASCADE
);

-- =============================================
-- ÍNDICES RECOMENDADOS
-- =============================================
CREATE INDEX idx_users_email ON "Users"("Email");
CREATE INDEX idx_posts_userid ON "Posts"("UserId");
CREATE INDEX idx_comments_postid ON "Comments"("PostId");
CREATE INDEX idx_comments_userid ON "Comments"("UserId");
CREATE INDEX idx_posttag_tagid ON "PostTag"("TagId");

