package com.xamarin.androidx.jetifierWrapper;

import com.android.tools.build.jetifier.processor.archive.ArchiveFile;
import com.android.tools.build.jetifier.processor.archive.ArchiveItem;

import java.io.FileOutputStream;
import java.io.IOException;
import java.util.concurrent.Callable;

import static com.android.tools.build.jetifier.standalone.Main.Companion;

class JetifierCallable implements Callable<JetifierData> {
    private JetifierData jetifierData;

    public JetifierCallable (JetifierData jetifierData) {
        this.jetifierData = jetifierData;
    }

    @Override
    public JetifierData call() throws Exception {
        if (jetifierData.isLibrary())
            Companion.main(jetifierData.getArguments());
        else if (jetifierData.isResource()) {
            jetifierData.getProcessor().visit((ArchiveFile)jetifierData.getArchiveItem());
            save(jetifierData.getArchiveItem(), jetifierData.getFileMapping().getTo().getAbsolutePath());
        } else if (jetifierData.isProGuard()) {
            jetifierData.getProGuardTransformer().runTransform((ArchiveFile)jetifierData.getArchiveItem());
            save(jetifierData.getArchiveItem(), jetifierData.getFileMapping().getTo().getAbsolutePath());
        }

        return jetifierData;
    }

    private void save(ArchiveItem archiveItem, String outputFilename) throws IOException {
        FileOutputStream outputStream = new FileOutputStream(outputFilename);
        archiveItem.writeSelfTo(outputStream);
    }
}
