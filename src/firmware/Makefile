.PHONY: all clean

ifeq '$(findstring ;,$(PATH))' ';'
	UNAME := Windows
else
	UNAME := $(shell uname 2>/dev/null || echo Unknown)
endif

# Select target controller (normally done from cmd line):
#TARGET_CONTROLLER = BBSHD
#TARGET_CONTROLLER = BBS02

# Compiler
CC = sdcc

# Target name
TARGET = bbs-fw

MAINSRC = main.c
SUBDIRS = 
		
CFLAGS = -Ddouble=float --std-c99 -D$(TARGET_CONTROLLER)
	
# Target Specific
ifeq ($(TARGET_CONTROLLER), BBSHD)
	CFLAGS += -mmcs51 --model-large --xram-size 3840	
	SUBDIRS += bbsx	
endif

ifeq ($(TARGET_CONTROLLER), BBS02)
	CFLAGS += -mmcs51 --model-large --xram-size 1792
	SUBDIRS += bbsx
endif

	
INCS = $(wildcard *.h $(foreach fd, $(SUBDIRS), $(fd)/*.h))
SRCS = $(filter-out main.c, $(wildcard *.c $(foreach fd, $(SUBDIRS), $(fd)/*.c)))
RELS := $(SRCS:.c=.rel)

INC_DIRS = -I./ $(addprefix -I, $(SUBDIRS))


all: precheck $(TARGET) hex
	
$(TARGET): $(MAINSRC) $(RELS)
	$(CC) -o $(TARGET).ihx $(INC_DIRS) $(CFLAGS) $(MAINSRC) $(RELS)

%.rel: %.c $(INCS)
	$(CC) -o $@ -c $(INC_DIRS) $(CFLAGS) $<

echo:
	$(info SRCS: $(SRCS))
	$(info RELS: $(RELS))
	$(info INCS: $(INCS))

precheck:
ifndef TARGET_CONTROLLER
	$(info TARGET_CONTROLLER is not specified.)
	$(info Set to one of [BBSHD, BBS02])
	$(info Example:)
	$(info $(null)  make all TARGET_CONTROLLER=BBSHD)
	$(error )
else ifeq ($(filter $(TARGET_CONTROLLER),BBSHD BBS02),)
	$(info Unsupported TARGET_CONTROLLER "$(TARGET_CONTROLLER)".)
	$(info Set to one of [BBSHD, BBS02])
	$(error )
endif
	$(info Building bbs-fw for $(TARGET_CONTROLLER))

hex:
ifeq ($(UNAME), Linux)
	@packihx bbs-fw.ihx > bbs-fw.hex
else
	@cmd /C tohex.bat
endif

clean:
ifeq ($(UNAME), Linux)
	@rm -f bbsx/*.hex *.hex
	@rm -f bbsx/*.ihx *.ihx
	@rm -f bbsx/*.asm *.asm
	@rm -f bbsx/*.rel *.rel
	@rm -f bbsx/*.lk  *.lk
	@rm -f bbsx/*.lst *.lst
	@rm -f bbsx/*.rst *.rst
	@rm -f bbsx/*.sym *.sym
	@rm -f bbsx/*.cdb *.cdb
	@rm -f bbsx/*.map *.map
	@rm -f bbsx/*.elf *.elf
	@rm -f bbsx/*.adb *.adb
	@rm -f bbsx/*.mem *.mem
else
	@cmd /C clean.bat
endif
	$(info Clean Finished)

.PHONY = all hex clean precheck echo
.SUFFIXES: .c .rel
