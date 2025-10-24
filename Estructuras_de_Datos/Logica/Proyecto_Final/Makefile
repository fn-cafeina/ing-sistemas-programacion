# Makefile para el Sistema de Gestión de Mantenimiento

CC = gcc
CFLAGS = -Wall -Wextra -std=c11 -g

SRC_DIR = src
INC_DIR = include
OBJ_DIR = obj
BIN_DIR = bin
DATA_DIR = data

# Incluir -I para que el compilador encuentre los headers en include/
CFLAGS += -I$(INC_DIR)

TARGET = gestor_mantenimiento
TARGET_PATH = $(BIN_DIR)/$(TARGET)

# Encontrar automáticamente todos los .c y .h
SRCS = $(wildcard $(SRC_DIR)/*.c)
HDRS = $(wildcard $(INC_DIR)/*.h)

# Generar la lista de archivos .o en el directorio obj/
OBJS = $(patsubst $(SRC_DIR)/%.c, $(OBJ_DIR)/%.o, $(SRCS))

# Regla principal
all: $(TARGET_PATH)

# Regla para enlazar el ejecutable
$(TARGET_PATH): $(OBJS) | $(BIN_DIR) $(DATA_DIR)
	@echo "Enlazando ejecutable: $@"
	$(CC) $(CFLAGS) -o $(TARGET_PATH) $(OBJS)
	@echo "¡Compilación exitosa!"

# Regla genérica para compilar .c en .o
# El .o depende del .c correspondiente y de todos los headers
$(OBJ_DIR)/%.o: $(SRC_DIR)/%.c $(HDRS) | $(OBJ_DIR)
	@echo "Compilando: $<"
	$(CC) $(CFLAGS) -c $< -o $@

# Reglas para crear directorios
$(BIN_DIR) $(OBJ_DIR) $(DATA_DIR):
	@mkdir -p $@

# Regla de limpieza
clean:
	@echo "Limpiando directorios obj/, bin/ y data/..."
	rm -rf $(OBJ_DIR) $(BIN_DIR) $(DATA_DIR)

.PHONY: all clean