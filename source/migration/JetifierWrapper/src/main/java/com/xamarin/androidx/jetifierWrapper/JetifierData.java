package com.xamarin.androidx.jetifierWrapper;

import com.android.tools.build.jetifier.processor.FileMapping;
import com.android.tools.build.jetifier.processor.Processor;
import com.android.tools.build.jetifier.processor.archive.ArchiveItem;
import com.android.tools.build.jetifier.processor.transform.proguard.ProGuardTransformer;

class JetifierData {
    private FileMapping fileMapping;
    private String[] arguments;
    private ArchiveItem archiveItem;
    private Processor processor;
    private ProGuardTransformer proGuardTransformer;
    private boolean isLibrary;
    private boolean isResource;
    private boolean isProGuard;

    public JetifierData (FileMapping fileMapping, String[] arguments) {
        this.fileMapping = fileMapping;
        this.arguments = arguments;
        this.isLibrary = true;
    }

    public JetifierData (FileMapping fileMapping, ArchiveItem archiveItem, Processor processor) {
        this.fileMapping = fileMapping;
        this.archiveItem = archiveItem;
        this.processor = processor;
        this.isResource = true;
    }

    public JetifierData (FileMapping fileMapping, ArchiveItem archiveItem, ProGuardTransformer proGuardTransformer) {
        this.fileMapping = fileMapping;
        this.archiveItem = archiveItem;
        this.proGuardTransformer = proGuardTransformer;
        this.isProGuard = true;
    }

    public FileMapping getFileMapping() {
        return fileMapping;
    }

    public String[] getArguments() {
        return arguments;
    }

    public ArchiveItem getArchiveItem() {
        return archiveItem;
    }

    public Processor getProcessor() {
        return processor;
    }

    public ProGuardTransformer getProGuardTransformer() {
        return proGuardTransformer;
    }

    public boolean isLibrary() {
        return isLibrary;
    }

    public boolean isResource() {
        return isResource;
    }

    public boolean isProGuard() {
        return isProGuard;
    }
}
