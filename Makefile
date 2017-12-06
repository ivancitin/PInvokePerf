SUBDIRS = libperf

all: clean subdirs msb run

msb:
	msbuild /p:Configuration=Release PInvokePerf.sln
     
.PHONY: subdirs $(SUBDIRS)
     
subdirs: $(SUBDIRS)
     
$(SUBDIRS):
	$(MAKE) -C $@

run:
	# 'unsafe' is a most powerfull optimization for mono, so use it to get better results for managed code
	# --aot is REQUIRED for internal calls. Otherwise you'll get MissingMethodException 
	cd PInvokePerf/bin/Release && ls -al && mono --optimize=unsafe ./PInvokePerf.exe

clean:
	rm -rf PInvokePerf/bin && rm -rf PInvokePerf/obj  && cd libperf && make clean
