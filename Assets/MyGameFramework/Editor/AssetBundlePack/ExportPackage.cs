using UnityEngine;
using UnityEditor;
public class ExportPackage : Editor
{

    [MenuItem("Tool/导出AssetBundle")]
    private static void exportAssetBundle()
    {
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/Assetbundle", BuildAssetBundleOptions.UncompressedAssetBundle);
    }
}
